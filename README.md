According to the provided Figma designs, three NoSQL collections are created.

1. Programs<br>
    This is to store program details.
    ```{
	"_id" : ObjectId("664c869d593e950d506ce350"),
	"programId" : "1",
	"title" : "Computer Science",
	"description" : "This program is about..."
}
```

2. ApplicationForms<br>
    The employer can enter questions they need to ask when creating the application forms. Two arrays are used to store personal information and additional questions. 
    ```{
	"_id" : ObjectId("664c870f593e950d506ce352"),
	"formId" : "form1",
	"programId" : "1",
	"personalInformationFields" : [
		{
			"fieldId" : "f1",
			"fieldName" : "First Name",
			"isRequired" : true,
			"isVisible" : true
		},
		{
			"fieldId" : "f2",
			"fieldName" : "Last Name",
			"isRequired" : true,
			"isVisible" : true
		},
		{
			"fieldId" : "f3",
			"fieldName" : "Email",
			"isRequired" : true,
			"isVisible" : true
		},
		{
			"fieldId" : "f4",
			"fieldName" : "Phone",
			"isRequired" : true,
			"isVisible" : true
		},
		{
			"fieldId" : "f5",
			"fieldName" : "Nationality",
			"isRequired" : true,
			"isVisible" : true
		},
		{
			"fieldId" : "f6",
			"fieldName" : "Current Residence",
			"isRequired" : true,
			"isVisible" : true
		},
		{
			"fieldId" : "f7",
			"fieldName" : "ID Number",
			"isRequired" : true,
			"isVisible" : true
		},
		{
			"fieldId" : "f8",
			"fieldName" : "Date of Birth",
			"isRequired" : true,
			"isVisible" : true
		},
		{
			"fieldId" : "f9",
			"fieldName" : "Gender",
			"isRequired" : true,
			"isVisible" : true
		}
	],
	"additionalQuestions" : [
		{
			"questionId" : "q1",
			"questionText" : "Why do you want to join this program?",
			"questionType" : "Paragraph"
		},
		{
			"questionId" : "q2",
			"questionText" : "Have you ever been rejected by the UK embassy?",
			"questionType" : "Yes/No"
		}
	]
}
```

3. Application<br>
   The data that the candidate fills in is stored in this collection.
   ```{
	"_id" : ObjectId("664d6fcb84b3fc2104fa00db"),
	"applicationId" : "app1",
	"formId" : "form1",
	"candidateId" : "cand1",
	"personalInformation" : {
		"First Name" : "John",
		"Last Name" : "Doe",
		"Email" : "john.doe@example.com",
		"Phone" : "+1234567890",
		"Nationality" : "American",
		"Current Residence" : "New York, USA",
		"ID Number" : "123456",
		"Date of Birth" : "1990-01-01",
		"Gender" : "Male"
	},
	"answers" : [
		{
			"questionId" : "q1",
			"answer" : "I want to join this program because I'm passionate about computer science and I believe this program will provide me with the knowledge and skills I need to excel in my career."
		},
		{
			"questionId" : "q2",
			"answer" : "No"
		}
	]
}
```

To manage data in these collections, five models have been used:

1. ApplicationForm
2. PersonalInformationFields
3. AdditionalQuestions
4. ApplicationForms
5. Answers

Service classes and controllers have been used to handle CRUD operations.

