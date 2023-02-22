﻿namespace OnlineSchool.App.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string firstName, string lastName, bool isStudent);
}