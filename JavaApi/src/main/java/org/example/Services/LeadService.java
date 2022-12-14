package org.example.Services;

import org.example.Models.DAO.impl.LeadDAOimpl;
import org.example.Models.Lead;

import java.util.List;

public class LeadService {
    List<Lead> leadList;
    LeadDAOimpl leadDAOimpl;

    public LeadService() {
        this.leadDAOimpl = new LeadDAOimpl();
    }

    public List<Lead> getAllLeads() {
        return leadDAOimpl.getAllLeads();
    }
}
