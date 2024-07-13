import React, { useState } from 'react';
import axios from 'axios';

const CustomerRelationForm = ({ customerId }) => {
    const [relationType, setRelationType] = useState('');
    const [relatedPersonFullName, setRelatedPersonFullName] = useState('');
    const [relations, setRelations] = useState([]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('/api/customerrelations', {
                RelationName: relationType,
                RelatedPersonFullName: relatedPersonFullName,
                ID_Customer: customerId
            });
            console.log(response.data);

         
            const newRelation = {
                RelationName: relationType,
                RelatedPersonFullName: relatedPersonFullName
            };
            setRelations([...relations, newRelation]);

           
            setRelationType('');
            setRelatedPersonFullName('');
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    value={relationType}
                    onChange={(e) => setRelationType(e.target.value)}
                    placeholder="Relation Type"
                    required
                />
                <input
                    type="text"
                    value={relatedPersonFullName}
                    onChange={(e) => setRelatedPersonFullName(e.target.value)}
                    placeholder="Related Person Full Name"
                    required
                />
                <button type="submit">Add Relation</button>
            </form>

            {/* İlişki listesi */}
            <div>
                <h2>Relations:</h2>
                {relations.map((relation, index) => (
                    <div key={index}>
                        <h3>Relation {index + 1}:</h3>
                        <p>Relation Name: {relation.RelationName}</p>
                        <p>Related Person Full Name: {relation.RelatedPersonFullName}</p>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default CustomerRelationForm;
