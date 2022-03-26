// A callback function is a function. it will passed as an argument to another function.
// most of the we used setTimeout callbacks function with asynchronous functions. for geting data from REST calls.

const myFunction = function () {
  alert("Hi!");
};
// runs only one time
setTimeout(myFunction, 3000);
// loop - every 1 sec
setInterval(myFunction, 1000);

// Promises
function getData() {
  return new Promise((resolve, reject) => {
    client
    .get("maintenance/getData")
    .then((response) => {
      resolve(response);
    })
    .catch((error) => {
      reject(error);
    });
  });
}

// Way-1 with .then and .chatch
const loadData1 = () => {
  getData()
  .then((response) => {
    this.setState({ response });
  })
  .catch((error) => {
    console.log(error.toString());
  });
};

// Way-2 with try and catch
const loadData2 = async () => {
  try {
    let response = await getData();
    this.setState({ response });
  } catch (error) {
    console.log(error.toString());
  }
};
