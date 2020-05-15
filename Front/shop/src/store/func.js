function parseJwt (token) {// eslint-disable-line no-unused-vars
    // do stuff
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));
    return JSON.parse(jsonPayload)
  }

function GetUser(){
    console.log("test")
}

function Sort(items){
    
      
    var up2 =items.sort(function (a, b) {
      if (a.date > b.date ) {
        return 1;
      }
      if (a.date< b.date ) {
        return -1;
      }
      return 0;
    })
    return up2.reverse()
  }

  function SortUser(items){
    
      
    var up2 =items.sort(function (a, b) {
      if (a.isAdmin  ) {
        return 1;
      }
      if (b.isAdmin ) {
        return -1;
      }
      return 0;
    })
    return up2.reverse()
  }

  function SortAllItems(items){
    
      
    var up2 =items.sort(function (a, b) {
      if (a.status==true && b.status ==false ) {
        return 1;
      }
      if (a.status==false< b.status ==true ) {
        return -1;
      }
      return 0;
    })
    return up2
  }






export {GetUser ,parseJwt,Sort ,SortAllItems,SortUser};