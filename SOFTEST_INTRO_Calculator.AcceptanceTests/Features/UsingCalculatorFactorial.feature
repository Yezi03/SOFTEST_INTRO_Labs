@Factorial
Feature: UsingCalculatorFactorial
  In order to calculate factorials quickly
  As a calculator user
  I want to be told the factorial of a number

  Scenario: Calculating a normal factorial
    Given I have a calculator
    When I have entered 5 into the calculator and press factorial
    Then the factorial result should be 120

  Scenario: Calculating the factorial identity case
    Given I have a calculator
    When I have entered 0 into the calculator and press factorial
    Then the factorial result should be 1

  Scenario Outline: Rejecting an unsupported factorial input
    Given I have a calculator
    When I have entered <value> into the calculator and press factorial
    Then factorial should be rejected

    Examples:
      | value |
      | -1    |
      | 21    |