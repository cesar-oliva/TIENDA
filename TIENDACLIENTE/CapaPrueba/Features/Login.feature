Feature: Login


@mytag
#Scenario Outline: user can login with correct credentials
#	Given I have started the application whith <Username>
#	When I write <Password>
#	Then the result should be <Answer>
#	Examples:
#	| Username | Password | Answer |
#	| Admin    | Admin    | true   |
#	| Cesar    | 54652    | false  |

Scenario: user can login with correct credentials
    Given I have started the application whith "Admin"  
    When I write Password "Admin"
    Then the result should be "true"