# Docker


```markdown
docker container run -it alpine sh    
```

```markdown
docker container run -d --name web nginx:alpine, -> -d  demonized, run in background
```

```markdown
docker container ls -> list running containers
```

```markdown
docker container ls -a -> list all containers. Running/stopped
```

```markdown
docker images -> list images
```

```markdown
docker container inspect <container-id> -> Get the details of container. pid of the container on host os
```

```markdown
docker container run --rm alpine date -> run and delete the container as soon as the job is done.
```

```markdown
docker container stop 7bbb0866e6fc -> stop the container.
```

```markdown
docker container rm web -> remove the container.
```

```markdown
cd /var/lib/docker/ on host machine, where the docker file system, images, container etc are stored.
```

```markdown
docker image pull fedora -> pull an image from docker repo
```

```markdown
from docker container, ctrl + pq will detach from the container and come back to host machine.
```

```markdown
docker container attach naughty_dijkstra -> attach to the already running container.
```

```markdown
docker container diff naughty_dijkstra -> Changes that have happened to the base image.
```

```markdown
docker container commit naughty_dijkstra santhosh:commit -> Changes are committed to the santhosh repo with version(TAG) commit as a new container image.
```


```markdown
docker image save repo:tag -o <where-to> -> export the image as a tar file.
```

```markdown
docker container rm -f dazzling_bartik -> remove container
```

```markdown
docker image rm santhosh:commit -> remove the image
```

```markdown
docker image load -i /tmp/santhosh-commit -> loads the image from the tar file.
```

```markdown
docker login -> to login into docker hub.
```

```markdown
docker info -> Info of the docker username, container, images, client, server
```

```markdown
Image name, registry-path/repository/tag
```

```markdown
docker image push santhoshic/santhosh:commit -> push the docker image to the repository
```

```markdown
docker image pull santhoshic/santhosh:commit -> pull from the docker repo
```

## Dockerfile
——————---------

```markdown
docker image build -t alpine:dockerfile08 . -> build image from the docker file in current directory(.).
```

```markdown
—no-cache option for not to cache the steps 
```

```markdown
CMD is the command to start. for e.g, “[“ngnix”, “-g”, “daemon off”]”
```

```markdown
ADD/COPY Build time instructions.
```

```markdown
CMD, ENTRYPOINT are run time instructions.
```

```markdown
docker container exec -it <container-name> sh
```

```markdown
sudo apt-get install bridge-utils 
brctl-show, show all the n/w bridges
```

```markdown
docker container run -d -p 8080:80 --name web2 nginx:alpine 
```

```markdown
docker container run -d -P --name web3 nginx:alpine
```

```markdown
docker container run -it --network=host alpine sh map all host ports to the containers’.
```

```markdown
docker network ls -> docker supports 5 types of n/w drivers, bridge, host, null macvlan  overlay
```

```markdown
docker network create --help
```


## Volume
—————----------
```markdown
docker container run -it -v /data --name datac alpine sh
```

```markdown
docker volume ls, even if the container is deleted the volume would still be there.
```

```markdown
docker volume prune -> remove all the unused volumes 
```

```markdown
ocker image prune -> remove all the images that are not used.
```

```markdown
docker volume create myvol -> create volume
```

```markdown
docker container run -it -v myvol:/data alpine sh
```

```markdown
cd /var/lib/docker/volumes/ -> the place on host machine where data will be saved.
```

```markdown
docker container run -it -v myvol:/data:ro alpine sh -> ro, read only
```

## Docker compose
——————------------------------------
```markdown
docker-compose up
```

```markdown
docker-compose up -d -> start the application in the detached mode.
```

```markdown
docker-compose ps -> status
```

```markdown
docker-compose down -> bring down the app, network, but volume still exists.
```

```markdown
docker-compose down -v -> remove the volume as well along with network and app.
```

```markdown
docker volume create portainer_data
```

```markdown
 docker run -d -p 9000:9000 -v /var/run/docker.sock:/var/run/docker.sock -v portainer_data:/data portainer/portainer
```

```markdown
Portainer is a GUI tool to manage the docker container and images that it self runs a container.
```


```markdown
Forcefully (-f) remove the dangling docker images
docker rmi -f $(docker images -f dangling=true -q) 
```

```markdown
# Assuming an Ubuntu Docker image - Run the Bash of container
$ docker run -it <image> /bin/bash
```

```markdown
delete file /Users/chandrashekarap/Library/Containers/com.docker.docker/Data/com.docker.driver.amd64-linux/Docker.qcow2 if you are getting, beware  it deletes all the containers, images etc. 
Error response from daemon: Error processing tar file(exit status 1): write /SVP/SVP/build/generated/mockable-android-25.jar: no space left on device. I deleted the file as described. However, I did an export of the images I wanted to retain before doing so. Then i imported the images after the delete. Worked great.
```

```markdown
docker rm $(docker ps -q -f 'status=exited')
docker rmi $(docker images -q -f "dangling=true")
docker volume rm $(docker volume ls -qf dangling=true)
```

```markdown
rm ~/Library/Containers/com.docker.docker/Data/com.docker.
driver.amd64-linux/Docker.qcow2
Restart docker
qemu-img resize ~/Library/Containers/com.docker.docker/Data/com.docker.
driver.amd64-linux/Docker.qcow2 +10G
```

```markdown
qemu-img create -f qcow2 ~/data.qcow2 120G
```
