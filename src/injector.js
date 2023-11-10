/* THIS IS ONLY SOURCE CODE, --> NOT <-- THE TAMPERMONKEY SCRIPT. IT IS OUTDATED, AND WILL NOT HAVE ANY MORE THEMES. */
var theme = "Dracula"

function main() {
    const injectCSS = css => {
        let x = document.createElement('style');
        x.type = ('text/css'); // deprecated, but i do not give two shits
        x.innerText = css;
        document.head.appendChild(x);
        return x;
    };

    let theme_storage = {
        "Dracula": "https://raw.githubusercontent.com/Storm99999/githubpp/main/src/themes/dracula/dracula_main.css"
    };

    if (theme == "Dracula") { fetch(theme_storage['Dracula']).then(response => response.text()).then(data => injectCSS(data)).catch(error => console.error('Error:', error)); };
}

main();
