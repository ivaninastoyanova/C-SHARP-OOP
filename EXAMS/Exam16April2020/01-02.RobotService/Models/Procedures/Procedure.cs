using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        public Procedure()
        {
            this.Robots = new List<IRobot>();
        }
        protected IList<IRobot> Robots { get; }
        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if(robot.ProcedureTime<procedureTime)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            foreach (var robot in this.Robots)
            {
                sb.AppendLine(robot.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
