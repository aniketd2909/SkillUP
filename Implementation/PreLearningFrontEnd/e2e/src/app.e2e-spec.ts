import { AppPage } from './app.po';
import { browser, by, logging } from 'protractor';

describe('workspace-project App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  // it('should display welcome message', async () => {
  //   await page.navigateTo();
  //   expect(await page.getTitleText()).toEqual('PreLearningFrontEnd app is running!');
  // });

  // afterEach(async () => {
  //   // Assert that there are no errors emitted from the browser
  //   const logs = await browser.manage().logs().get(logging.Type.BROWSER);
  //   expect(logs).not.toContain(jasmine.objectContaining({
  //     level: logging.Level.SEVERE,
  //   } as logging.Entry));
  // });

  it('should display welcome message', async () => {

    await page.navigateToHome();
    await browser.sleep(3000);
    expect(await page.getTitleText()).toEqual('Created By Campus Minds');

  });

  it('should display welcome message', async () => {

    await page.navigateToExperienceFeed();
    await browser.sleep(3000);
   // expect(await page.getTitleText()).toEqual('Created By Campus Minds');

  });

  it('should login for user ', async () => {  
    await page.navigateToHome();
    await browser.driver.findElement(by.id('loginButton')).click();  
    await browser.sleep(2000);
    await browser.driver.findElement(by.id('email')).sendKeys('aniket@gmail.com');
    await browser.sleep(2000);
    await browser.driver.findElement(by.id('password')).sendKeys('123456');
    await browser.sleep(2000);
    await browser.driver.findElement(by.className('btn btn-primary')).click();
    await browser.sleep(5000);    
    // await browser.driver.get('http://localhost:4200/authentication/login');
    // await browser.switchTo().alert().accept();  
    // await browser.sleep(5000); 
    expect(await page.checkUserLogin()).toEqual('Logout');
  });




});
