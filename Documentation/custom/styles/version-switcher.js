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

$(function () {
    const requestURL = `${document.location.origin}/metadata.json`;
    $.getJSON(requestURL, populateVersionSwitcher);

    window.refresh = function (_) {
        $.getJSON(requestURL, populateVersionSwitcher);
    };

    $(document).click(function (e) {
        if (e.target.id == 'component-select-current-display')
            $('#component-select-current-display').toggleClass('component-select__current--is-active');
        else
            $('#component-select-current-display').removeClass('component-select__current--is-active');
    });
});
