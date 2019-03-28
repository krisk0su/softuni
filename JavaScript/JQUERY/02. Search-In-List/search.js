function search() {
   let search = $('#searchText').val();
   let counter = 0;

   $('li').toArray().forEach(function(e) {
     
      if(e.textContent.includes(search)){
         counter++;

         let startIndex = e.textContent.indexOf(search);
         let length = search.length;

         let bold ='<b>'+search+'</b>';
         let starter = startIndex+length;
         let follower = e.textContent.substr(starter, e.textContent.length - 1)
         let result = bold + follower;

         e.textContent = result;
         
      }

   })

   $('#result').text(counter)
}