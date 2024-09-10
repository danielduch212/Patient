namespace Patient.Domain.Exceptions;

public class NotFoundException(string resourceType, string resourceId) : 
    Exception($"{resourceType} with given Id: {resourceId} doesn't exist")
{

}
