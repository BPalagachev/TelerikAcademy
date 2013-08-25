<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:students ="urn:students">
  <xsl:template match="/">
    <html>
      <body>
        <h1>This works in IE and you need to remove the namespace from xml file in order to work!!!</h1>
        <div>
          <xsl:for-each select="/students/student">
            <h2>
              <xsl:value-of select="name"/>
            </h2>
            <ul>
              <li>
                <xsl:value-of select="name"/>
              </li>
              <li>
                <xsl:value-of select="gender"/>
              </li>
              <li>
                <xsl:value-of select="birthdate"/>
              </li>
              <li>
                <xsl:value-of select="phone"/>
              </li>
              <li>
                <xsl:value-of select="email"/>
              </li>
              <li>
                <xsl:value-of select="course"/>
              </li>
              <li>
                <xsl:value-of select="specialty"/>
              </li>
              <li>
                <xsl:value-of select="facultyNumber"/>
              </li>
            </ul>
          </xsl:for-each>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>