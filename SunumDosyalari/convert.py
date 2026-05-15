import markdown
import glob

md_files = glob.glob('*.md')
for f in md_files:
    with open(f, 'r', encoding='utf-8') as file:
        text = file.read()
    html = markdown.markdown(text, extensions=['tables', 'fenced_code'])
    
    html_content = f'''<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<style>
body {{ font-family: Calibri, sans-serif; padding: 20px; }}
table {{ border-collapse: collapse; width: 100%; margin-bottom: 20px; }}
th, td {{ border: 1px solid #ddd; padding: 8px; text-align: left; }}
th {{ background-color: #f2f2f2; }}
pre {{ background-color: #f8f8f8; padding: 10px; border: 1px solid #ddd; }}
</style>
</head>
<body>
{html}
</body>
</html>'''

    out_f = f.replace('.md', '.html')
    with open(out_f, 'w', encoding='utf-8') as out_file:
        out_file.write(html_content)
    print(f'Converted {f} to {out_f}')
