package org.example.Models.DAO.impl;

import org.example.Data.ConnectionManager;
import org.example.Models.DAO.LeadDAO;
import org.example.Models.Lead;

import javax.xml.transform.Result;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class LeadDAOimpl implements LeadDAO {
    List<Lead> leadList;

    @Override
    public void createLead(Lead l) {

    }

    @Override
    public List<Lead> getAllLeads() {
        this.leadList = new ArrayList<Lead>();
        Connection connection = ConnectionManager.getConnection();
        Statement statement;
        ResultSet resultSet = null;
        try {
            String query = "SELECT * FROM pipenetwork.lead";
            statement = connection.createStatement();
            resultSet = statement.executeQuery(query);
            while (resultSet.next()) {
                long id = resultSet.getLong("id");
                String nome = resultSet.getString("nome");
                String cognome = resultSet.getString("cognome");
                String nascita = resultSet.getString("nascita");
                String cellulare = resultSet.getString("cellulare");
                String email = resultSet.getString("email");
                String indirizzo = resultSet.getString("indirizzo");
                String arrivoLead = resultSet.getString("arrivoLead");
                boolean inNewsLetter = resultSet.getBoolean("inNewsLetter");
                boolean isCalled = resultSet.getBoolean("isCalled");
                boolean inFreeTrial = resultSet.getBoolean("inFreeTrial");
                long stage = resultSet.getLong("stage");
                Lead l = new Lead(id, nome, cognome, nascita, cellulare, email, indirizzo, arrivoLead, inNewsLetter, isCalled, inFreeTrial, stage);
                leadList.add(l);
            }
        }
        catch (SQLException e) {
            e.printStackTrace();
        }
        return leadList;
    }

    @Override
    public Lead getLeadByID(long l) {
        return  null;
    }

    @Override
    public void deleteLeadByID(long l) {

    }

    @Override
    public Lead updateLead(Lead l) {
        return null;
    }
}
