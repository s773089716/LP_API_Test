# LP_API_Test

1. The key focus in this challenge is to keep words which has about 370,000 records in a separate text file that could be read via http. Data could be saved in a static variable as a singleton instead of having a caching mechanism but I decided to go with caching because it would be a better practise. However, data would be read only once from the file and cach, after that singleton was used, so that, subsequent requests would be more smoothen.

2. Since, there was no architectural pattern mentioned, layered architecture was used. Onion or N-tier is a very simple approch for this kind of requirement. The concerns were segregrated according to different perspectives.

3. To simplify the structure, a folder called Core was used. All the base/core/interfaces/abstract classes are supposed to be resides in this folder. In a production environment, this could be a seperate class library.

4. Separate folders were used DTO/Model/Repository/Service/Infracture etc. Instead of having dependency resolvers in the middleware directly, a separate extension was created, so that, the startup class would be cleaner.

5. Instead of having the data provider directly in the middleware, separate factory was used because it would provide more flexibility to exchange different providers in a live environment according to the requirement.

6. Response/Request parameters were wrapped in classes as then a single envelop could be used to transport data here and there. No models were needed in this requirement. DTO did the part wanted.

7. However, final solution given tests were not succeeded in the given tool, which could not be identified, sometimes could be my bad of refferring some nuget packages. But the solution perfectly works in visual studio and all 4 tests written were succeeded.

8. The git repository of the same solution which included in my git has been provided here below for your reference. Hope, the solution would be considered kindly.

https://github.com/s773089716/LP_API_Test

9. The screenshot for the execution of unit tests in powershell has been attached to the git hub project,

https://github.com/s773089716/LP_API_Test/blob/master/UnitTests2.JPG

