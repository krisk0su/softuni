function solve(args, order){
  let arr = args.map(Number);
  let orderType = order;

  if(orderType=='asc'){
    return(arr.sort((a, b) => a - b));
  }
  else if(orderType == 'desc'){
    return(arr.sort((a, b) => b - a));
  }
}
