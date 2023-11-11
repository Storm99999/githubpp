// ==UserScript==
// @name         GitHub++
// @namespace    https://github.com/Storm99999/githubpp
// @version      0.1
// @description  A github theme utilization tool
// @author       Storm
// @match        https://github.com/*
// @icon         https://www.google.com/s2/favicons?sz=64&domain=github.com
// @grant        none
// ==/UserScript==

(function() {
    'use strict';

    var theme = "Aura"

    function main() {
        const injectCSS = css => {
            let x = document.createElement('style');
            x.type = ('text/css'); // deprecated, but I do not give two shits
            x.innerText = css;
            document.head.appendChild(x);
            return x;
        };

        // Fetch themes.json dynamically
        fetch('https://raw.githubusercontent.com/Storm99999/githubpp/main/src/theme_list.json')
            .then(response => response.json())
            .then(theme_storage => {
                // Check if the selected theme exists in the retrieved data
                if (theme_storage[theme]) {
                    fetch(theme_storage[theme])
                        .then(response => response.text())
                        .then(data => injectCSS(data))
                        .catch(error => console.error('Error:', error));
                } else {
                    console.error('Error: Theme not found in themes.json');
                }
            })
            .catch(error => console.error('Error fetching themes.json:', error));
    }

    main();
})();
