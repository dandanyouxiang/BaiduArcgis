using System;

namespace ArcgisBaiduMap.ArcgisExtend
{
    /// <summary>
    /// ��������ϵ (GCJ-02)��ٶ�����ϵ (BD-09) ת��������
    /// </summary>
    public class BDGCJLatLonHelper
    {
        /*
         *�ο���
         *BD09����ϵ�����ٶ�����ϵ��GCJ02����ϵ�����ܺ������ϵ��
         */
        #region ����
        const double x_pi = 3.14159265358979324 * 3000.0 / 180.0;
        #endregion 
        #region ��GCJ-02����ת����BD-09����
        /// <summary>
        /// ��GCJ-02����ת����BD-09����
        /// </summary>
        /// <param name="gcjPoint">GCJ-02����</param>
        /// <returns>BD-09����</returns>
        public static LatLngPoint GCJ02ToBD09(LatLngPoint gcjPoint)
        {
            LatLngPoint _bdPoint = new LatLngPoint();
            double _x = gcjPoint.LonX, y = gcjPoint.LatY;
            double _z = Math.Sqrt(_x * _x + y * y) + 0.00002 * Math.Sin(y * x_pi);
            double _theta = Math.Atan2(y, _x) + 0.000003 * Math.Cos(_x * x_pi);
            _bdPoint.LonX = _z * Math.Cos(_theta) + 0.0065;
            _bdPoint.LatY = _z * Math.Cos(_theta) + 0.006;
            return _bdPoint;
        }

        #endregion 
        #region ��BD-09����ת����GCJ-02����
        /// <summary>
        /// ��BD-09����ת����GCJ-02����
        /// </summary>
        /// <param name="bdPoint">BD-09����</param>
        /// <returns>GCJ-02����</returns>
        public static LatLngPoint BD09ToGCJ02(LatLngPoint bdPoint)
        {
            LatLngPoint _gcjPoint = new LatLngPoint();
            double _x = bdPoint.LonX - 0.0065, _y = bdPoint.LatY - 0.006;
            double _z = Math.Sqrt(_x * _x + _y * _y) - 0.00002 * Math.Sin(_y * x_pi);
            double _theta = Math.Atan2(_y, _x) - 0.000003 * Math.Cos(_x * x_pi);
            _gcjPoint.LonX = _z * Math.Cos(_theta);
            _gcjPoint.LatY = _z * Math.Sin(_theta);
            return _gcjPoint;
        }
        #endregion 
    }
}