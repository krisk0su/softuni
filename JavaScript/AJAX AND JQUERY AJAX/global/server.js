let express = require('express');

var app = express();

app.use(express.static('./global'));
app.listen(3000, function () {
  console.log('Example app listening on port 3000!');
});