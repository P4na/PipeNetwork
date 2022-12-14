package org.example.Controllers;
import spark.Spark.*;
import com.google.gson.Gson;
import org.example.Services.LeadService;

import static spark.Spark.*;

public class LeadController {
    Gson gson;
    LeadService leadService;

    public LeadController(LeadService leadService) {
        this.leadService = leadService;
        this.gson = new Gson();
    }
    public void startServices () {
        options("/*",
                (request, response) -> {

                    String accessControlRequestHeaders = request
                            .headers("Access-Control-Request-Headers");
                    if (accessControlRequestHeaders != null) {
                        response.header("Access-Control-Allow-Headers",
                                accessControlRequestHeaders);
                    }

                    String accessControlRequestMethod = request
                            .headers("Access-Control-Request-Method");
                    if (accessControlRequestMethod != null) {
                        response.header("Access-Control-Allow-Methods",
                                accessControlRequestMethod);
                    }

                    return "OK";
                });

        before((request, response) -> response.header("Access-Control-Allow-Origin", "*"));
        get("/Leads",(req,res)->{
            res.type("application/json");
            return leadService.getAllLeads();
        },gson::toJson);
    }
}
