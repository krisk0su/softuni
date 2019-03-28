function initializeTable() {
    $('#createLink').on("click", createEntry);

    function createEntry(){
        let country = $('#newCountryText').val()
        let capital = $('#newCapitalText').val()

        let $table = $('#countriesTable');
        
        var $row =$('<tr>'+
                    '<td>'+country+'</td>'+
                    '<td>'+'sfdsfdsf'+'</td>'+
                    '<td>'+capital+'</td>'+
                    
                    '</tr>');    
        

        $table.append($row);
        //<td><a href="#" id="createLink">[Create]</a></td>
    }
}