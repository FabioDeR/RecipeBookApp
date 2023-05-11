export class Utils {

  static FilterList(filterBy: string, list: []): any {    
    filterBy = filterBy.toLocaleLowerCase();
    let newlist: any = list.filter((e: any) => e.name.toLocaleLowerCase().includes(filterBy))
    return newlist
  }

}
