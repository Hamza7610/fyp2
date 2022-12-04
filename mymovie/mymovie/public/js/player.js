
$(document).ready(function()
{
    openmodal();
    initializePlayer();
});
function initializePlayer() {
    if ($('#player').length) {
        const player = new Plyr('#player');
    } else {
        return false;
    }
    return false;
}
