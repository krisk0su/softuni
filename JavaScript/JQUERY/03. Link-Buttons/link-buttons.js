function attachEvents() {
    $('a').click(function(evt) {
       
        evt.preventDefault();
        removeOthers();
        this.classList.add('selected')
        
    });

    function removeOthers(){
        $('a').removeClass('selected')
    }
}