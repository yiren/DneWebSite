$(document).ready(function () {

    $('#newDoc').qtip({
        content: '<h4>英文(2007~迄今)</h4>',
        position: {
            my: 'left center',
            at: 'right center',
            target:$('#newDoc')
        },
        show: {
            effect: function (offset) {
                $(this).slideDown(100);
            }
        },
        style:{
            classes:'qtip-green qtip-rounded'
        }
    });
    $('#oldDoc').qtip({
        content: '<ul class="list"><li><h4>中文(1998~迄今)</h4></li><li><h4>英文(1998~2007)</h4></li></ul>',
        position: {
            my: 'left top',
            at: 'right center',
            target:$('#oldDoc')
        },
        show: {
            effect: function (offset) {
                $(this).slideDown(100);
            }
        },
        style:{
            classes:'qtip-green qtip-rounded'
        }
    });
});