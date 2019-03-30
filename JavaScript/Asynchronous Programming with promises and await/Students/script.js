function doMagic() {
  console.log("magicc");
  const baseUrl = "https://baas.kinvey.com/";
  const appKey = "kid_BJXTsSi-e";
  const endPoint = "447b8e7046f048039d95610c1b039390";
  const userName = "guest";
  const password = "guest";
  const headers = {
    Authorization: `Basic ${btoa(userName + ":" + password)}`,
    "Content-Type": "application/json"
  };

  magic();
  async function magic() {
    try {
      let obj = await fetch(baseUrl + "appdata/" + appKey + "/" + endPoint, {
        method: "GET",
        headers
      });
      let res = await obj.json();
      console.log(res);
    } catch (error) {
      console.log(error.message);
    }
  }
}
