import { Injectable } from '@angular/core';

export interface Menu {
  state: string;
  name: string;
  type: string;
  icon: string;
}

const MENUITEMS = [
  { state: 'dashboard', name: 'Dashboard', type: 'link', icon: 'av_timer' },
  { state: 'instrutores', type: 'link', name: 'Instrutores', icon: 'perm_contact_calendar' },
  { state: 'lives', type: 'link', name: 'Lives', icon: 'screenshot_monitor' },
  { state: 'inscritos', type: 'link', name: 'Incritos', icon: 'card_membership' },
  { state: 'inscricoes', type: 'link', name: 'Inscrições', icon: 'receipt' },
];

@Injectable()
export class MenuItems {
  getMenuitem(): Menu[] {
    return MENUITEMS;
  }
}
