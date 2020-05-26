# Article

Build local docker image
To localy navigate to article root folder and execute this command:

docker build .

Docker repo url
https://hub.docker.com/repository/docker/kgtrue/article

The API is documented using using swagger and is accessed using the url path /api examples
1. IIS https://localhost/api (setuphostname and bindings in iis).
2. IIS express https://localhost:port/api
3. Docker https://host:port/api(the internal port defined in the docker image is 80 and 433 use port mapping if the ports are in use)

Pull this gitrepo or use the docker image mentioned earlier.

The solution required framework Is netcoreapp3.1
