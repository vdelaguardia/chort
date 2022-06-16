export type ChoreModel = {
    id: number;
    householdId?: number;
    assigneeId?: number;
    name: string;
    difficulty?: number;
    frequency?: number;
    choreEvents?: Array<ChoreEventModels>
}

export type ChoreEventModels = {
    id: number;
    scheduledChoreId: number;
    completedDate?: Date;
}

export enum Frequencies{
    daily = "Daily",
    bidiurnal = "Every other day",
    weekly = "Weekly",
    biweekly = "Bi-Weekly",
    monthly = "Monthly",
    seasonally = "Seasonally"
}
