# gppcreator
Uses a `color dump` from gpptool to convert into a fully functional theme

# Install
[Click here](https://cdn.discordapp.com/attachments/1170748927927140506/1172682223909093466/gppcreator.exe)

# Usage
![image](https://github.com/Storm99999/githubpp/assets/87811650/fa1e5b28-8ce2-4918-86d0-13ae852f2eb8)
* Powershell: `.\gppcreator.exe -fmake C:\Users\$env:UserName\source\repos\gpptool\gpptool\bin\Debug\colordump_1483348.txt`
* Default Windows terminal: `gppcreator.exe -fmake C:\Users\%username%\source\repos\gpptool\gpptool\bin\Debug\colordump_1483348.txt`
Make sure to actually replace the colordump path with your own that you obtained from `gpptool`

# What to do after
Incase you want to help make gpp more great, you can open a pull request and add in the theme, it must not be total garbage though. Otherwise if it's for your private use, do not worry. Theres a guide.
* Create a GitHub Repository
* Create a file, call it whatever + ".css" at the end
* Put the CSS script that `gppcreator` created inside that exact file
* Copy the raw link to the file (github)
* Open the GPP script in Tampermonkey, Incase you haven't installed GPP yet, follow the guide on the main README.md
* Add another theme entry, like shown on the image below
![image](https://github.com/Storm99999/githubpp/assets/87811650/5e4d4394-6048-42fe-9c85-87279cb4b712)
* Make sure it links to **YOUR** raw file
* Change your current theme to the theme entry name
* Profit!
