import { TestBed, inject } from '@angular/core/testing';

import { StatusReportService } from './status-report.service';

describe('StatusReportService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [StatusReportService]
    });
  });

  it('should be created', inject([StatusReportService], (service: StatusReportService) => {
    expect(service).toBeTruthy();
  }));
});
