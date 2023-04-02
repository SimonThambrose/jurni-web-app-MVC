describe('My First Test', () => {
  it('Visits the Kitchen Sink', () => {
    // Visit the JurniWebApp default page
    cy.visit('https://localhost:7061/')

    // Click on the Home link and verify the URL
    cy.contains('Home').click();
    cy.url().should('include', '/');

    // Click on the Privacy link and verify the URL
    cy.contains('Privacy').click();
    cy.url().should('include', '/Home/Privacy');
  })
})