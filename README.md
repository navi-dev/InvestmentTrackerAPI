# InvestmentTrackerAPI-

For generating the client
java -jar swagger-codegen-cli-2.3.1.jar generate -i http://localhost:44326/swagger/v1/swagger.json -l typescript-angular -o /var/tmp/angular_api_client --additional-properties npmName=@navi-dev/investment-tracker-api,snapshot=true,ngVersion=6.0.0