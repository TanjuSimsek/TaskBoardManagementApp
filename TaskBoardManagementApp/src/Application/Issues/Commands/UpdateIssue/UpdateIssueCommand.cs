﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TaskBoardManagementApp.Application.Common.Interfaces;
using TaskBoardManagementApp.Application.Issues.Dtos;
using TaskBoardManagementApp.Domain.Entities;
using TaskBoardManagementApp.Domain.Enums;

namespace TaskBoardManagementApp.Application.Issues.Commands.UpdateIssue;

public record class UpdateIssueCommand : IRequest<UpdatedIssueDto>
{
    public Guid Id { get; init; }
    public Guid ProjectId { get; init; }
    public Guid AssigneeId { get; init; }
    public Guid ReporterId { get; init; }
    public int Number { get; init; }
    public string Title { get; init; }
    public IssueType Types { get; init; }
    public IssueStatus Status { get; init; }
    public DateTime DueDate { get; init; }
}

public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommand, UpdatedIssueDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdateIssueCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UpdatedIssueDto> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
    {
        var issue = await _dbContext.Issues
            .FindAsync(new object[] { request.Id }, cancellationToken);

        // TODO: Business rules will be created..

        var mapped = _mapper.Map(request, issue);

        // TODO: Will be refactored..

        var updatedIssue = _dbContext.Issues.Update(mapped);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UpdatedIssueDto>(updatedIssue.Entity);
    }
}