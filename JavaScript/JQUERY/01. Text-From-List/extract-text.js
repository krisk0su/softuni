function extractText() {
   let result = $('li').toArray().map(function(e) {
      return e.textContent;
   })
   
   console.log(result.join(', '))
   
}
   