import json
import random

categories = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H']
template = '\n{"name": "{nameVar}",\n"category": "{categoryVar}",\n"position": [{"x": {xVar}, "y": {yVar}}],\n"brightness": {brightnessVar}}'
finalString = '['

for num in range(3):
    brightness = []
    for num2 in range(30):
        # append random numer between 0 and 100
        brightness.append(random.randint(0, 1000)/10)
    string = template.replace('{nameVar}', 'name' + str(num)).replace('{categoryVar}', random.choice(categories)).replace('{xVar}', str(random.randint(0, 100))).replace('{yVar}', str(random.randint(0, 100))).replace('{brightnessVar}', str(brightness))
    finalString += string + ', '
finalString = finalString[:-2] + ']'
json_obj = json.loads(finalString)
#save json to file data.json
with open('data.json', 'w') as outfile:
    json.dump(json_obj, outfile)
print(json_obj)