(function ($) {
    $(function () {
        $(document).ready(function () {
            //init Tags Input
            $('#tagsName').tagsinput({
                maxTags: 1,
                typeahead: {
                    source: ['Buea', 'Douala', 'Kribi', 'Yaounde']
                }
            });
        });
    });
})(jQuery);