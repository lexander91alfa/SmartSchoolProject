-- -----------------------------------------------------
-- Schema SmartSchool
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `SmartSchool` ;
USE `SmartSchool` ;

-- -----------------------------------------------------
-- Table `SmartSchool`.`aluno`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SmartSchool`.`alunos` (
  `id` INT NOT NULL,
  `nome` VARCHAR(60) NOT NULL,
  `sobrenome` VARCHAR(60) NOT NULL,
  `telefone` VARCHAR(20) NULL,
  PRIMARY KEY (`id`));


-- -----------------------------------------------------
-- Table `SmartSchool`.`professores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SmartSchool`.`professores` (
  `id` INT NOT NULL,
  `nome` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC));


-- -----------------------------------------------------
-- Table `SmartSchool`.`disciplinas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SmartSchool`.`disciplinas` (
  `id` INT NOT NULL,
  `nome` VARCHAR(50) NOT NULL,
  `professor_id` INT NOT NULL,
  PRIMARY KEY (`id`, `professor_id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) ,
  INDEX `fk_disciplina_professor1_idx` (`professor_id` ASC) ,
  CONSTRAINT `fk_disciplina_professor1`
    FOREIGN KEY (`professor_id`)
    REFERENCES `SmartSchool`.`professores` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


-- -----------------------------------------------------
-- Table `SmartSchool`.`alunosdisciplinas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SmartSchool`.`alunosdisciplinas` (
  `disciplina_id` INT NOT NULL,
  `aluno_id` INT NOT NULL,
  INDEX `fk_alunodisciplina_aluno1_idx` (`aluno_id` ASC),
  CONSTRAINT `fk_alunodisciplina_disciplina1`
    FOREIGN KEY (`disciplina_id`)
    REFERENCES `SmartSchool`.`disciplinas` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_alunodisciplina_aluno1`
    FOREIGN KEY (`aluno_id`)
    REFERENCES `SmartSchool`.`alunos` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);