# Basic Experiment with ASP.NET Core, Prometheus and Graphana

## Purpose

Nothing really fancy here, it's a playground allowing me to play easily with Prometheus and Graphana (using ASP.NET Core).

Nothing here is production ready.

## Build & Run

```
docker-compose up -d
```

* Web app is reachable on http://localhost:8080
* Prometheus is reachable on http://localhost:9090
* Graphana is reachable on http://localhost:3000

## Setup

Prometheus monitors the app on startup (see `prometheus.yml`).

Graphana have to be configured (follow the recommendations). Default login : `admin` / `admin`.

## Generate load

The app is a default ASP.NET Core app, only modified to be coupled with Prometheus, and to allow load generation through a tool like Apache `ab` or [hey](https://github.com/rakyll/hey) .

Call (GET) the root URL (http://localhost:8080) with two query parameters :
* `pause` : time (ms) to wait in each request.
* `listSize` : size of a list of strings generate in each request (to force memory consumtion and gargage collections).

Exemple :

```
ab -n 10000 -c10 "http://localhost:8080/?pause=10&listSize=1000"
```

## Shutdown & cleanup

```
docker-compose down

docker rmi promtrial_app
docker image prune --filter label=stage=builder

docker volume rm promtrial_data-graphana
docker volume rm promtrial_data-prometheus
```