import { of } from 'rxjs';


export class MockTopSecretService {
  fetchTopSecretData(token: string, ClientId: number) {
    return of([1, 2, 3, 4, 5]);
  }
}
