import { browser, by, element } from 'protractor';

export class AppPage {
  
  // async navigateTo(): Promise<unknown> {
  //   return browser.get(browser.baseUrl);
  // }

  // async getTitleText(): Promise<string> {
  //   return element(by.css('app-root .content span')).getText();
  // }

  async navigateToHome(): Promise<unknown> {
    return  browser.driver.get('http://localhost:4200/home');
  }

  async getTitleText(): Promise<string> {
    return element(by.className('cardSubtitle')).getText();
  }

  async checkUserLogin(): Promise<string> {

    return element(by.className('logoutButton')).getText();
  }

  async navigateToExperienceFeed(): Promise<unknown> {
    return  browser.driver.get('http://localhost:4200/experience-feed/add');
  }




  




}
