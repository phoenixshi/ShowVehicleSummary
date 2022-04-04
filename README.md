# ShowVehicleSummary
Both front end and back end

For some configuration problem, I can not fork the repository, 
So I upload the code in my personal github.

For backend code, you can just download the code and run it in Visual Studio locally.
For front code, you need to download the code and run npm install and npm start to run it locally. Please make sure the backend is running.

To make it cross origin, i added some configuration in the backend code, using Cors.
I provided two apis for frontend to call.
One is to get all the models and year summary information.
Another one is to get the years for a particular model.
They will be called in the frontend to show the summary information and List of years for a particular model.
Some unit tests and integration test are added in the backend as well.

For frontend , I installed Redux and configure the store reducer action to replace the current state.
It will show the summary information when first loading.
I added a select drop down list to select a model and show the years details for it.
When seleciing "All", it will show all the models and year summary again.
I did not add tests code but i added some comments to show my thoughts.

Thanks.

