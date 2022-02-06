export class Chore {
  id: number;
  name: string;
  assigneeId: number;
  difficulty: number;
  frequency: {
    id: number,
    description: string
  };
  lastCompleted: Date;
}
