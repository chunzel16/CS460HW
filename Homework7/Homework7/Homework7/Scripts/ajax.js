$(document).ready(function () {
    $('#text-input').bind('keypress', function (e) {
        if (e.which === 32) {
            giphySearch();
            e.preventDefault;
        }
        function giphySearch() {

            var txt = $('#text-input').val();

            var lastitem = txt.split(" ").pop();


            var source = "Home/Sticker/" + txt;
            if (!boring(lastitem)) {
                $.ajax({
                    type: "GET",
                    dataType: "json",
                    data: { "txt": lastitem },
                    url: source,
                    success: showGifs,
                    error: errorOnAjax

                });
            }
            else {
                var s = "<label>" + lastitem + "</label>";
                $('#giphy').append(" " + s);
            }
            function boring(word) {

                var boringWords = ["i'm", "to", "my", "and", "it", "where", "i", "me", "we", "us", "those",];
                var boring = false;
                for (var i = 0; i < boringWords.length; i++) {
                    if (word === boringWords[i]) {
                        boring = true;
                    }
                }

                return boring;

            }
            function showGifs(data) {

                var emptystr = "";
                var giphyUrl = data.data.images.fixed_height_still.url;
                console.log(giphyUrl);

                emptystr += "<img src='" + giphyUrl + "' width=150px, height=150px/>";


                $('#giphy').append(emptystr);

            }

            function errorOnAjax() {
                console.log("error");
            }

        }
    });
});



