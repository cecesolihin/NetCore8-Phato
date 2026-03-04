import os
import re

dir_path = r"d:\COURSES\ThePatho\ThePatho.Features\Organization"

def process_file(filepath):
    with open(filepath, 'r', encoding='utf-8') as f:
        content = f.read()
    
    # We only care about concrete classes, not interfaces
    if "interface I" in content and "class" not in content:
        return
    
    if "class " not in content:
        return
        
    original = content
        
    # 1. Add using if not present
    if "ThePatho.Provider.UserContext" not in content:
        # find the last using
        lines = content.split('\n')
        last_using_idx = -1
        for i, line in enumerate(lines):
            if line.startswith('using '):
                last_using_idx = i
        if last_using_idx != -1:
            lines.insert(last_using_idx + 1, 'using ThePatho.Provider.UserContext;')
            content = '\n'.join(lines)
            
    # 2. Add private readonly ICurrentUserService currentUserService; 
    # and update constructor
    if "ICurrentUserService" not in content:
        # We need to find the constructor and the class name
        class_match = re.search(r'public class (\w+Service)', content)
        if class_match:
            class_name = class_match.group(1)
            
            # Find constructor
            # e.g. public CompanyBankService(DapperContext _dapperContext)
            # Find fields block
            # #region [FIELDS & CTOR]
            # private readonly DapperContext dapperContext;
            
            # This regex looks for the constructor
            ctor_pattern = rf"public\s+{class_name}\s*\((.*?)\)"
            ctor_match = re.search(ctor_pattern, content)
            
            if ctor_match:
                params_str = ctor_match.group(1)
                new_params_str = params_str + ", ICurrentUserService _currentUserService" if params_str.strip() else "ICurrentUserService _currentUserService"
                
                # Replace params
                content = content.replace(ctor_match.group(0), f"public {class_name}({new_params_str})")
                
                # Inject field assignment inside the constructor (find the first '{' after constructor)
                # This could be tricky with regex, let's do it by finding the constructor signature line
                lines = content.split('\n')
                for i, line in enumerate(lines):
                    if f"public {class_name}" in line and "(" in line and ")" in line:
                        # Find the '{'
                        j = i
                        while j < len(lines) and "{" not in lines[j]:
                            j += 1
                        if j < len(lines):
                            # insert assignment after {
                            lines.insert(j + 1, "            currentUserService = _currentUserService;")
                        break
                content = '\n'.join(lines)

                # Add field declaration
                # Find private readonly DapperContext or similar
                lines = content.split('\n')
                field_inserted = False
                for i, line in enumerate(lines):
                    if "private readonly " in line and not field_inserted:
                        lines.insert(i, "        private readonly ICurrentUserService currentUserService;")
                        field_inserted = True
                        break
                
                if not field_inserted:
                    # just insert before the constructor
                    for i, line in enumerate(lines):
                        if f"public {class_name}(" in line:
                            lines.insert(i, "        private readonly ICurrentUserService currentUserService;")
                            break
                            
                content = '\n'.join(lines)

    # 3. Replace currentUserService.GetUserName() ?? "system" and ModifiedBy  = currentUserService.GetUserName() ?? "system"
    # User asked for: InsertBy dari currentUserService.GetUserName() ?? "system"
    
    content = re.sub(r'InsertedBy\s*=\s*"[sS]ystem"', 'InsertedBy = currentUserService.GetUserName() ?? "system"', content)
    content = re.sub(r'ModifiedBy\s*=\s*"[sS]ystem"', 'ModifiedBy = currentUserService.GetUserName() ?? "system"', content)

    if original != content:
        with open(filepath, 'w', encoding='utf-8') as f:
            f.write(content)
        print(f"Updated {filepath}")

for root, dirs, files in os.walk(dir_path):
    for f in files:
        if f.endswith("Service.cs") and not f.startswith("I"):
            process_file(os.path.join(root, f))
