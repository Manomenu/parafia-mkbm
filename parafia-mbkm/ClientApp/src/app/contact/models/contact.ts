export interface contact {
  id: number;
  contactTitle: string;
  contactLines: { category: string; value: string; icon: string }[];
}
