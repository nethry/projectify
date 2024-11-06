namespace Domain.Exceptions;

public class InvalidProjectStatusException(string message)
    : Exception(message);