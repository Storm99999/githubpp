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

(function () {
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

        fetch('https://raw.githubusercontent.com/Storm99999/githubpp/main/src/theme_list.json')
            .then(response => response.json())
            .then(theme_storage => {
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

    const showThemeSelector = () => {
        let existingDropdown = document.getElementById('theme-selector-dropdown');
        if (existingDropdown) {
            for (let i = 0; i <= 300; i++) {
                existingDropdown.remove();
            }

            return;
        }

        let dropdownContainer = document.createElement('div');
        dropdownContainer.id = 'theme-selector-dropdown';
        dropdownContainer.style.position = 'fixed';
        dropdownContainer.style.top = '0';
        dropdownContainer.style.left = '0';
        dropdownContainer.style.padding = '30px';
        dropdownContainer.style.background = '#1f1f1f';
        dropdownContainer.style.border = '1px solid #ccc';
        dropdownContainer.style.zIndex = '9999';
        fetch("https://raw.githubusercontent.com/Storm99999/githubpp/main/src/theme_list.json")
            .then(response => response.json())
            .then(themeStorage => {
                let themeSelect = document.createElement('select');
                // populate
                for (let themev in themeStorage) {
                    let option = document.createElement('option');
                    option.value = themev;
                    option.text = themev;
                    themeSelect.appendChild(option);
                }

                themeSelect.value = theme;
                themeSelect.addEventListener('change', (event) => {
                    theme = event.target.value;
                    fetch('https://raw.githubusercontent.com/Storm99999/githubpp/main/src/theme_list.json')
                        .then(response => response.json())
                        .then(theme_storage => {
                            // Check if the selected theme exists in the retrieved data
                            if (theme_storage[theme]) {
                                // Inject the selected theme's CSS
                                const injectCSS = css => {
                                    let x = document.createElement('style');
                                    x.type = ('text/css'); // deprecated, but I do not give two shits
                                    x.innerText = css;
                                    document.head.appendChild(x);
                                    return x;
                                };
                                fetch(theme_storage[theme])
                                    .then(response => response.text())
                                    .then(data => injectCSS(data))
                                    .catch(error => console.error('Error:', error));
                            } else {
                                console.error('Error: Theme not found in themes.json');
                            }
                        })
                        .catch(error => console.error('Error fetching themes.json:', error));
                });

                dropdownContainer.appendChild(themeSelect);
                document.body.appendChild(dropdownContainer);
            })
            .catch(error => console.error('Error fetching themes.json:', error));
    };


    document.addEventListener('keydown', (event) => {
        const activeElement = document.activeElement;
        const isInputOrTextarea = activeElement.tagName === 'INPUT' ||
                              activeElement.tagName === 'TEXTAREA' ||
                              (activeElement.hasAttribute('contenteditable') &&
                               activeElement.getAttribute('contenteditable').toLowerCase() === 'true');

        if (!isInputOrTextarea && event.key === '-') {
            showThemeSelector();
        }
    });


    main();
})();
