import React, { useState } from 'react';
import axios from 'axios';

const CustomerJobForm = ({ customerId }) => {
    const [companyName, setCompanyName] = useState('');
    const [startDate, setStartDate] = useState('');
    const [endDate, setEndDate] = useState('');
    const [position, setPosition] = useState('');
    const [salary, setSalary] = useState('');
    const [jobs, setJobs] = useState([]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('/api/customerjobs', {
                CompanyName: companyName,
                StartDate: startDate,
                EndDate: endDate || null,
                Position: position,
                Salary: salary,
                ID_Customer: customerId
            });
            console.log(response.data);

        
            const newJob = {
                CompanyName: companyName,
                StartDate: startDate,
                EndDate: endDate || 'Ongoing',
                Position: position,
                Salary: salary
            };
            setJobs([...jobs, newJob]);

           
            setCompanyName('');
            setStartDate('');
            setEndDate('');
            setPosition('');
            setSalary('');
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    value={companyName}
                    onChange={(e) => setCompanyName(e.target.value)}
                    placeholder="Company Name"
                    required
                />
                <input
                    type="date"
                    value={startDate}
                    onChange={(e) => setStartDate(e.target.value)}
                    placeholder="Start Date"
                    required
                />
                <input
                    type="date"
                    value={endDate}
                    onChange={(e) => setEndDate(e.target.value)}
                    placeholder="End Date (Optional)"
                />
                <input
                    type="text"
                    value={position}
                    onChange={(e) => setPosition(e.target.value)}
                    placeholder="Position"
                    required
                />
                <input
                    type="text"
                    value={salary}
                    onChange={(e) => setSalary(e.target.value)}
                    placeholder="Salary"
                    required
                />
                <button type="submit">Add Job</button>
            </form>

            {/* İş listesi */}
            <div>
                <h2>Jobs:</h2>
                {jobs.map((job, index) => (
                    <div key={index}>
                        <h3>Job {index + 1}:</h3>
                        <p>Company Name: {job.CompanyName}</p>
                        <p>Start Date: {job.StartDate}</p>
                        <p>End Date: {job.EndDate}</p>
                        <p>Position: {job.Position}</p>
                        <p>Salary: {job.Salary}</p>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default CustomerJobForm;