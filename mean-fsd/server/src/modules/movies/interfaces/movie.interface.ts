import { Document } from 'mongoose';

export interface Movie extends Document{
  readonly movieid?: string;
  readonly title: string;
  readonly year: number;
  readonly cast: string;
  readonly rating: number;
  readonly genre: string;
  readonly story: string;
  readonly created_at: Date;
  readonly updated_at: Date;
}
