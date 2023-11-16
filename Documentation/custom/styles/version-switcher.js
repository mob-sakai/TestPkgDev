function populateVersionSwitcher(metadata) {
    if (!metadata) return;

    metadata.include.forEach(v => {
        $('#version-switcher-ul').append($(`
            <a style="color:#000;" href="${v.url}">
                <li class="component-select__option" style='justify-content:space-between;'>
                    ${v.version} <span style="color:#aaa;">${v.unity}+</span>
                </li>
            </a>
        `));
    });
}

function updateVersionSwitcher() {
    const offline = location.hostname === "localhost" || location.hostname === "127.0.0.1";
    const requestURL = '../metadata.json';
    $.getJSON(requestURL, m => {
        if (offline){
            populateVersionSwitcher(m);
        }
        else{
            $.getJSON(m.metadata, populateVersionSwitcher)
        }
    });
}

$(function () {
    updateVersionSwitcher();

    window.refresh = function (_) {
        updateVersionSwitcher();
    };

    $(document).click(function (e) {
        if (e.target.id == 'component-select-current-display')
            $('#component-select-current-display').toggleClass('component-select__current--is-active');
        else
            $('#component-select-current-display').removeClass('component-select__current--is-active');
    });
});
