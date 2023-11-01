<img alt="kibana-query-example" src="https://github.com/AndersBjerregaard/big-systems/blob/master/dotnet-elk-example/kibana-query-example.png">

```
docker compose up
```

Give the elk stack a moment to initialize. This is mostly because elasticsearch takes a bit to initialize, and the logstash & kibana instances depend on elasticsearch.

Then hit the web api endpoint:

```
curl http://localhost:5012/WeatherForecast
```

Next, you should be able to see the logs either through kibana or through querying elasticsearch from its url api. Example of querying through Kibana is shown in the picture. Which is done from the developer console in Kibana.
